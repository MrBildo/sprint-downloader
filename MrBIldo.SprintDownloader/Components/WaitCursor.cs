namespace MrBildo.SprintDownloader.Components
{
    public class WaitCursor : IDisposable
    {
        private readonly Cursor _previousCursor;
        private readonly Form _form;

        public WaitCursor(Form form)
        {
            _form = form;
            _previousCursor = form.Cursor;
            form.Cursor = Cursors.WaitCursor;
        }

        public void Dispose() => _form.Cursor = _previousCursor;
    }
}
