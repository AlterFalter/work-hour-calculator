using WorkHourCalculator.Helper;

namespace WorkHourCalculator.Models
{
	public class WindowsUserConfiguration : Configuration<WindowsUserConfiguration>
    {
		public string LastUsedFilepath
		{
			get => this.ReadField(nameof(this.LastUsedFilepath));
			set
			{
				this.AddOrSetField(nameof(this.LastUsedFilepath), value);
			}
		}
    }
}
