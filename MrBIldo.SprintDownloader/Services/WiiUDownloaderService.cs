


namespace MrBildo.SprintDownloader.Services
{
    public struct WiiUTitleMetadata
    {
        public uint SignatureType;

        public byte[] Signature; // 256 bytes

        public byte[] Padding0; // 60 bytes

        public string Issuer; // 64 bytes

        public byte Version;

        public byte CaCrlVersion; // certificate authority certificate revocation list version

        public byte SignerCrlVersion; // signer certificate revocation list version

        public byte Padding1; // 1 byte

        public string SystemVersion;

        public string TitleId;

        public string TitleType;

        public string GroupId;

        public string AppType; // 0x80000000 or for updates 0x0800001B ???

        public byte[] Reserved0; // 58 bytes

        public uint AccessRights;

        public ushort TitleVersion;

        public ushort ContentCount;

        public ushort BootIndex;

        public ushort MinorVersion;

        public byte[] ContentInfoHash; // SHA256 32 bytes

        public WiiUTitleContentInfo[] ContentInfos; // 0x1E8

        public WiiUTitleContent[] Contents;
    }

    public struct WiiUTitleContentInfo
    {
        public ushort Index;

        public ushort Count;

        public byte[] SHA256Hash; // 32 bytes
    }

    public struct WiiUTitleContent
    {
        public uint ContentId;

        public ushort Index;

        public ushort Type;

        public ulong Size;

        public byte[] Hash; // 32 bytes
    }

    //public class WiiUDownload(string id, string name) : IDownload
    //{
    //    public string Id { get; } = id; // this is required for WiiU

    //    public string Name { get; } = name;

    //    public IDictionary<string, string> Metadata { get; } = new Dictionary<string, string>(); // TODO: make this a full getter/setter
    //}

    //public class WiiUDownloaderService : IDownloaderService<WiiUDownload>
    //{
    //    private readonly HttpClient _httpClient;

    //    public WiiUDownloaderService(HttpClient httpClient)
    //    {
    //        _httpClient = httpClient;
    //    }

    //    public string Name => "wii-u";

    //    public ValueTask AddToQueue(WiiUDownload download) => throw new NotImplementedException();
    //}


    // add to queue
    // remove from queue
    // move in queue (up/down)
    // pause
    // resume
    // cancel
    // retry

    // get status
    // get progress
    // get speed
    // get eta
    // get error

}
