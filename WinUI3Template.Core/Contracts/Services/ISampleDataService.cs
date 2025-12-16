using System.Collections.Generic;
using System.Threading.Tasks;
using WinUI3Template.Core.Models;

namespace WinUI3Template.Core.Contracts.Services;

// Remove this class once your pages/features are using your data.
public interface ISampleDataService
{
    Task<IEnumerable<SampleOrder>> GetListDetailsDataAsync();
}
