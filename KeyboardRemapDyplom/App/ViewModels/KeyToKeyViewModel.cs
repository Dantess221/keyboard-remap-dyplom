namespace App.ViewModels
{
    using MVVM_Tools.Code.Classes;

    public class KeyToKeyViewModel : BindableBase
    {
        private int _mappedKey;

        private int _sourceKey;

        public int MappedKey
        {
            get => this._mappedKey;
            set => this.SetProperty(ref this._mappedKey, value);
        }

        public int SourceKey
        {
            get => this._sourceKey;
            set => this.SetProperty(ref this._sourceKey, value);
        }
    }
}