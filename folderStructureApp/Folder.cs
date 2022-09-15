namespace folderStructureApp;

public class Folder
{
    public string id { get; set; }
    public DateTime syncedDate { get; set; }
    public DateTime createdDate { get; set; }
    public int fileSize { get; set; }
    public string resourceId { get; set; }
    public string storageId { get; set; }
    public string fullPath { get; set; }
    public string displayName { get; set; }
    public string parentFolderId { get; set; }
    public string fileDownloadLink { get; set; }
    public string fileType { get; set; }
    public string createdByUserId { get; set; }
    public string createdByUser { get; set; }
    public string createdByTeamId { get; set; }
    public string createdByTeam { get; set; }
    public string mime { get; set; }
    public bool isFolder { get; set; }
    public bool isHidden { get; set; }
}
