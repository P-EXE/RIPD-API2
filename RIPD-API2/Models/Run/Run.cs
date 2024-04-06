using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using RIPD_API2.Models.Imported;

namespace RIPD_API2.Models;

public class Run
{
  public ObjectId Id { get; set; }
  public List<Location> Locations { get; set; }
}