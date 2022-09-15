
var fileName = "ZNM-DCT-WIR-AR-AC-000015[00]_A1";

// remove extension
var splitName = fileName.Split('-');

var projCode = splitName[0];
var organisation = splitName[1];
var docType = splitName[2];
var dicipline = splitName[3];
var subDicipline = splitName[4];
var sequentialNumber = splitName[5];



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
// PRoject Code (ZNM) - Organisation (DCT) - Doc Type (WIR) - Dicipline (AR) - Sub Dicipline (AC) - Sequential Number (000015)

//ZNM(Project Code) -
//DCT(Organisation that created document) -
//MIR(Type of Document(MIR material inspection request)) -
//AR(Dicipline(architectural)) - 
//AC(sub - discipline) - 
//000003(sequential number based on document type / discipline)..


// So this is the 3rd (0000003) form of MIR-AR


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
    int count;
    LinkedListNode? _head;
    public LinkedList()
    {
        _head = null;
        count = 0;
    }
    public void PrependNode(string value)
    {
        var linkedListNode = new LinkedListNode(value);
        linkedListNode.next = _head;
        _head = linkedListNode;
        count++;
    }

    public void AppendNode(string value)
    {
        var newNode = new LinkedListNode(value);

        if (_head == null)
        {
            _head = newNode;
            count++;
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

                //Console.WriteLine(runner.value);
                runner = runner.next;
            }
        }

    }
}