using System.Threading.Tasks;

namespace Yondr_Finance
{
    public interface INumberPickerDialog
    {
        Task<(bool, int)> ShowPicker(string title, string okButtonText, string cancelButtonText, NumberPickerOptions options);
    }
}