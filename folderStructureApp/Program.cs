
using folderStructureApp;
using System.Text.Json;

var fileName = "level1a-DCT-WIR-AR-AC-000015[00]_A1";
//var fileName = "ZNM-DCT-WIR-AR-AC-000015[00]_A1";

// remove extension
var splitName = fileName.Split('-');

var projCode = splitName[0];
var organisation = splitName[1];
var docType = splitName[2];
var dicipline = splitName[3];
var subDicipline = splitName[4];
var sequentialNumber = splitName[5];


//Dictionary<int, string> dicFoldersToCreate = new Dictionary<int, string>();

LinkedList<string> folderPathToCreate = AddItemsToList(projCode, organisation, docType, dicipline, subDicipline, sequentialNumber);

LinkedList<string> AddItemsToList(params string[] collection)
{
    LinkedList<string> output = new();
    foreach (var item in collection)
    {
        output.AddLast(item);
    }
    return output;
}

var projectDocuments = getDocuments();

if (projectDocuments != null)
{

    var foldersToCreateDto = getFolderToCreate(projectDocuments, folderPathToCreate);

    var createThis = folderPathToCreate;


}

FolderToCreate getFolderToCreate(List<Folder> currentFolders, LinkedList<string> folderPathToCreate)
{
    // need to output starting parent ID, and remaining folders to create
    var output = new FolderToCreate();
    var rootFolder = currentFolders.Where(x => x.fullPath == "/").FirstOrDefault();

    if (rootFolder == null) return output;

    var rootFolderId = rootFolder.id;



    //var files = projectDocuments.Where(x => x.isFolder == false).ToArray();
    var folders = projectDocuments.Where(x => x.isFolder).ToArray();


    var firstLevelFolders = folders.Where(x => x.parentFolderId == rootFolderId).ToArray();

    if (firstLevelFolders != null)
    {
        var projectCodeFolder = firstLevelFolders.FirstOrDefault(x => x.displayName == projCode);

        if (projectCodeFolder == null)
        {
            output.ParentFolderId = rootFolderId;
            output.FolderStructure = folderPathToCreate;
            return output;
        }
        else
        {
            folderPathToCreate.RemoveFirst();
        }

        // second level organisation
        var firstLevelIds = firstLevelFolders.Select(x => x.id).ToArray();
        var secondLevelFolders = folders.Where(x => firstLevelIds.Contains(x.parentFolderId)).ToArray();

        var organisationFolder = secondLevelFolders.FirstOrDefault(x => x.displayName == organisation);
        if (organisationFolder == null)
        {
            output.ParentFolderId = projectCodeFolder.id;
            output.FolderStructure = folderPathToCreate;
            return output;
        }
        else
        {
            folderPathToCreate.RemoveFirst();
        }


        // 3rd level (docType)
        var secondLevelIds = secondLevelFolders.Select(x => x.id).ToArray();
        var thirdLevelFolders = folders.Where(x => secondLevelIds.Contains(x.parentFolderId)).ToArray();

        var docTypeFolder = thirdLevelFolders.FirstOrDefault(x => x.displayName == docType);
        if (docTypeFolder == null)
        {
            output.ParentFolderId = organisationFolder.id;
            output.FolderStructure = folderPathToCreate;
            return output;
        }
        else
        {
            folderPathToCreate.RemoveFirst();
        }


        // 4th level (dicipline)
        var thirdLevelIds = thirdLevelFolders.Select(x => x.id).ToArray();
        var fourthLevelFolders = folders.Where(x => thirdLevelIds.Contains(x.parentFolderId)).ToArray();

        var diciplineFolder = fourthLevelFolders.FirstOrDefault(x => x.displayName == dicipline);
        if (diciplineFolder == null)
        {
            output.ParentFolderId = docTypeFolder.id;
            output.FolderStructure = folderPathToCreate;
            return output;
        }
        else
        {
            folderPathToCreate.RemoveFirst();
        }


        // 5th level (subDicipline)
        var fourthLevelIds = fourthLevelFolders.Select(x => x.id).ToArray();
        var fifthLevelFolders = folders.Where(x => fourthLevelIds.Contains(x.parentFolderId)).ToArray();

        var subDiciplineFolder = fifthLevelFolders.FirstOrDefault(x => x.displayName == subDicipline);
        if (subDiciplineFolder == null)
        {
            output.ParentFolderId = diciplineFolder.id;
            output.FolderStructure = folderPathToCreate;
            return output;
        }
        else
        {
            folderPathToCreate.RemoveFirst();
        }

        // 6th level (sequentialNumber)

        var fifthLevelIds = fifthLevelFolders.Select(x => x.id).ToArray();
        var sixthLevelFolders = folders.Where(x => fifthLevelIds.Contains(x.parentFolderId)).ToArray();

        var sequentialNumberFolder = sixthLevelFolders.FirstOrDefault(x => x.displayName == sequentialNumber);
        if (sequentialNumberFolder == null)
        {
            output.ParentFolderId = subDiciplineFolder.id;
            output.FolderStructure = folderPathToCreate;
            return output;
        }
        else
        {
            folderPathToCreate.RemoveFirst();
        }

    }
    return output;
}

List<Folder>? getDocuments()
{
    using StreamReader r = new(@"D:\Dev\Projects\Practise Projects\folderStructureApp\folderStructureApp\folders.json");
    string json = r.ReadToEnd();
    var items = JsonSerializer.Deserialize<List<Folder>>(json);
    return items;
}



















//var fileName = "ZNM-DCT-WIR-AR-AC-000015[00]_A1";

//// remove extension
//var splitName = fileName.Split('-');

//var projCode = splitName[0];
//var organisation = splitName[1];
//var docType = splitName[2];
//var dicipline = splitName[3];
//var subDicipline = splitName[4];
//var sequentialNumber = splitName[5];








var linkedList = new LinkedList();
linkedList.AppendNode(projCode);
linkedList.AppendNode(organisation);
linkedList.AppendNode(docType);
linkedList.AppendNode(dicipline);
linkedList.AppendNode(subDicipline);
linkedList.AppendNode(sequentialNumber);

linkedList.PrintList();

linkedList.PrependNode("ooooooooooooooh");

linkedList.PrintList();

Console.ReadLine();



// linked nodes 
//--- each node contains a piece of data, and a link to another node.

// [A] => [B] => [C] => NULL
// [5]    [9]    [2] 
// [B]    [C]    [NULL] 

class LinkedListNode
{
    public string value;
    public LinkedListNode? next;
    public LinkedListNode(string value)
    {
        this.value = value;
        next = null;
    }
}

class LinkedList
{
    int _count;
    LinkedListNode? _head;
    public LinkedList()
    {
        _head = null;
        _count = 0;
    }
    public void PrependNode(string value)
    {
        var linkedListNode = new LinkedListNode(value);
        linkedListNode.next = _head;
        _head = linkedListNode;
        _count++;
    }

    public void AppendNode(string value)
    {
        var newNode = new LinkedListNode(value);

        if (_head == null)
        {
            _head = newNode;
            _count++;
        }
        else
        {
            // get head node
            bool atEnd = false;
            LinkedListNode runner = _head;
            while (atEnd == false)
            {
                if (runner.next != null)
                {
                    // go next
                    runner = runner.next;
                }
                else
                {
                    // we are at the end
                    runner.next = newNode;
                    atEnd = true;
                }
            }
        }

    }

    public void PrintList()
    {
        if (_head != null)
        {
            LinkedListNode? runner = _head;
            while (runner != null)
            {
                Console.WriteLine($"Node: {runner.value}");
                runner = runner.next;
            }
        }

    }
}

class FolderToCreate
{
    public string ParentFolderId { get; set; } = string.Empty;
    public LinkedList<string> FolderStructure { get; set; } = new();
}