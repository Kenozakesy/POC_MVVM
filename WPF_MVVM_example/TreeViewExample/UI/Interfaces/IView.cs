namespace WPF_MVVM_example.UI.Interfaces
{
    public interface IView
    {
        void ShowMessage(string text);
        bool ConfirmMessage(string title, string text);
    }
}
