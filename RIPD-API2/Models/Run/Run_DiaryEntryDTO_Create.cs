using RIPD_API2.Models.Imported;

namespace RIPD_API2.Models;

public class Run_DiaryEntryDTO_Create : DiaryEntryDTO_Create
{
  public List<Location> Locations { get; set; }
}
