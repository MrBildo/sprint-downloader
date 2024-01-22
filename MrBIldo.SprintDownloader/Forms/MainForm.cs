using System.Buffers.Binary;
using System.Text;
using MrBildo.SprintDownloader.Components;

namespace MrBildo.SprintDownloader.Forms
{
    public partial class MainForm : Form
    {
        private readonly IFormFactory _formFactory;
        private readonly DownloadManager _downloadManager;

        public MainForm(IFormFactory formFactory, DownloadManager downloadManager)
        {
            _formFactory = formFactory;
            _downloadManager = downloadManager;

            _downloadManager.Intialize();

            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private async void menuLoadWiiU_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (new WaitCursor(this))
                {
                    var selectTitlesDialog = _formFactory.Create<WiiUTitles>();

                    await selectTitlesDialog.LoadTitlesAsync(openFileDialog.FileName);

                    if (selectTitlesDialog.ShowDialog() == DialogResult.OK)
                    {
                        // add selected titles to download queue
                        var downloadQueue = selectTitlesDialog.GetQueuedTitles();
                    }
                }
            }
        }

        private void buttonLoadTMD_Click(object sender, EventArgs e)
        {
            var file = @"C:\Users\mrbil\OneDrive\Desktop\wii-u-working\ROMS\Angry Birds Trilogy [Game] [0005000010138a00]\title.tmd";

            var data = File.ReadAllBytes(file).AsSpan();

            var tmd = new WiiUTitleMetadata
            {
                SignatureType = BinaryPrimitives.ReadUInt32BigEndian(data[..sizeof(uint)]),
                Signature = data.Slice(0x04, 256).ToArray(),
                Padding0 = data.Slice(0x104, 60).ToArray(),
                Issuer = Encoding.ASCII.GetString(data.Slice(0x140, 64).ToArray()).TrimEnd('\0'),
                Version = data.Slice(0x180, sizeof(byte))[0],
                CaCrlVersion = data.Slice(0x181, sizeof(byte))[0],
                SignerCrlVersion = data.Slice(0x182, sizeof(byte))[0],
                Padding1 = data.Slice(0x183, sizeof(byte))[0],
                SystemVersion = BinaryPrimitives.ReadUInt64BigEndian(data.Slice(0x184, sizeof(ulong))).ToString("X16"),
                TitleId = BinaryPrimitives.ReadUInt64BigEndian(data.Slice(0x18C, sizeof(ulong))).ToString("X16"),
                TitleType = BinaryPrimitives.ReadUInt32BigEndian(data.Slice(0x194, sizeof(uint))).ToString("X16")[8..],
                GroupId = BinaryPrimitives.ReadUInt16BigEndian(data.Slice(0x198, sizeof(ushort))).ToString("X16")[8..],
                AppType = BinaryPrimitives.ReadUInt32BigEndian(data.Slice(0x19A, sizeof(uint))).ToString("X16")[8..],
                Reserved0 = data.Slice(0x19E, 58).ToArray(),
                AccessRights = BinaryPrimitives.ReadUInt32BigEndian(data.Slice(0x1D8, sizeof(uint))),
                TitleVersion = BinaryPrimitives.ReadUInt16BigEndian(data.Slice(0x1DC, sizeof(ushort))),
                ContentCount = BinaryPrimitives.ReadUInt16BigEndian(data.Slice(0x1DE, sizeof(ushort))),
                BootIndex = BinaryPrimitives.ReadUInt16BigEndian(data.Slice(0x1E0, sizeof(ushort))),
                MinorVersion = data.Slice(0x1E2, sizeof(byte))[0],
                ContentInfoHash = data.Slice(0x1E4, 32).ToArray(),
                ContentInfos = new WiiUTitleContentInfo[64]
            };

            // Read content info
            for (var i = 0; i < 64; i++)
            {
                var offset = 0x204 + (i * 0x24);

                tmd.ContentInfos[i] = new WiiUTitleContentInfo
                {
                    Index = BinaryPrimitives.ReadUInt16BigEndian(data.Slice(offset, sizeof(ushort))),
                    Count = BinaryPrimitives.ReadUInt16BigEndian(data.Slice(offset + 0x02, sizeof(ushort))),
                    SHA256Hash = data.Slice(offset + 0x04, 32).ToArray(),
                };
            }

            // Read content
            tmd.Contents = new WiiUTitleContent[tmd.ContentCount];

            for (var i = 0; i < tmd.ContentCount; i++)
            {
                var offset = 0x0B04 + (i * 0x30);

                tmd.Contents[i] = new WiiUTitleContent
                {
                    ContentId = BinaryPrimitives.ReadUInt16BigEndian(data.Slice(offset, sizeof(uint))),
                    Index = BinaryPrimitives.ReadUInt16BigEndian(data.Slice(offset + 0x04, sizeof(ushort))),
                    Type = BinaryPrimitives.ReadUInt16BigEndian(data.Slice(offset + 0x06, sizeof(ushort))),
                    Size = BinaryPrimitives.ReadUInt64BigEndian(data.Slice(offset + 0x08, sizeof(ulong))),
                    Hash = data.Slice(offset + 0x10, 32).ToArray(),
                };
            }
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            //var download = (IDownload)new object(); // for testing only

            //_downloadManager.Add(download, Guid.Empty);

            //Task.Run(async () =>
            //{
            //    try
            //    {
            //        await _downloadManager.StartAsync(download);
            //    }
            //    catch (Exception ex)
            //    {
            //        // Handle or log the exception
            //        Invoke(new Action(() =>
            //        {
            //            // Update the UI if needed (make sure to marshal calls to the UI thread)
            //            MessageBox.Show("Error starting download: " + ex.Message);
            //        }));
            //    }
            //});
        }
    }
}
