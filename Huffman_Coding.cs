using System;

class MinHNode
{
    public int freq;
    public char item;
    public MinHNode left, right;
}

class MinH
{
    public int size;
    public int capacity;
    public MinHNode[] array;
}

class HuffmanCoding
{
    private const int MAX_TREE_HT = 50;

    static void Main()
    {
        char[] arr = { 'A', 'B', 'C', 'D' };
        int[] freq = { 5, 1, 6, 3 };
        int size = arr.Length;

        Console.WriteLine("Char | Huffman code ");
        Console.WriteLine("----------------------");
        HuffmanCodes(arr, freq, size);
    }

    static MinHNode newNode(char item, int freq)
    {
        MinHNode temp = new MinHNode();
        temp.left = temp.right = null;
        temp.item = item;
        temp.freq = freq;
        return temp;
    }

    static MinH createMinHeap(int capacity)
    {
        MinH minHeap = new MinH();
        minHeap.size = 0;
        minHeap.capacity = capacity;
        minHeap.array = new MinHNode[minHeap.capacity];
        return minHeap;
    }

    static void printArray(int[] arr, int n)
    {
        for (int i = 0; i < n; ++i)
            Console.Write(arr[i]);

        Console.WriteLine();
    }

    static void swapMinHNode(ref MinHNode a, ref MinHNode b)
    {
        MinHNode t = a;
        a = b;
        b = t;
    }

    static void minHeapify(ref MinH minHeap, int idx)
    {
        int smallest = idx;
        int left = 2 * idx + 1;
        int right = 2 * idx + 2;

        if (left < minHeap.size && minHeap.array[left].freq < minHeap.array[smallest].freq)
            smallest = left;

        if (right < minHeap.size && minHeap.array[right].freq < minHeap.array[smallest].freq)
            smallest = right;

        if (smallest != idx)
        {
            swapMinHNode(ref minHeap.array[smallest], ref minHeap.array[idx]);
            minHeapify(ref minHeap, smallest);
        }
    }

    static bool checkSizeOne(ref MinH minHeap)
    {
        return (minHeap.size == 1);
    }

    static MinHNode extractMin(ref MinH minHeap)
    {
        MinHNode temp = minHeap.array[0];
        minHeap.array[0] = minHeap.array[minHeap.size - 1];
        --minHeap.size;
        minHeapify(ref minHeap, 0);
        return temp;
    }

    static void insertMinHeap(ref MinH minHeap, MinHNode minHeapNode)
    {
        ++minHeap.size;
        int i = minHeap.size - 1;

        while (i > 0 && minHeapNode.freq < minHeap.array[(i - 1) / 2].freq)
        {
            minHeap.array[i] = minHeap.array[(i - 1) / 2];
            i = (i - 1) / 2;
        }

        minHeap.array[i] = minHeapNode;
    }

    static void buildMinHeap(ref MinH minHeap)
    {
        int n = minHeap.size - 1;
        int i;

        for (i = (n - 1) / 2; i >= 0; --i)
            minHeapify(ref minHeap, i);
    }

    static bool isLeaf(ref MinHNode root)
    {
        return (root.left == null && root.right == null);
    }

    static MinH createAndBuildMinHeap(char[] item, int[] freq, int size)
    {
        MinH minHeap = createMinHeap(size);

        for (int i = 0; i < size; ++i)
            minHeap.array[i] = newNode(item[i], freq[i]);

        minHeap.size = size;
        buildMinHeap(ref minHeap);

        return minHeap;
    }

    static MinHNode buildHfTree(char[] item, int[] freq, int size)
    {
        MinHNode left, right, top;
        MinH minHeap = createAndBuildMinHeap(item, freq, size);

        while (!checkSizeOne(ref minHeap))
        {
            left = extractMin(ref minHeap);
            right = extractMin(ref minHeap);
            top = newNode('$', left.freq + right.freq);
            top.left = left;
            top.right = right;
            insertMinHeap(ref minHeap, top);
        }
        return extractMin(ref minHeap);
    }
    static void printHCodes(ref MinHNode root, int[] arr, int top)
    {
        if (root.left != null)
        {
            arr[top] = 0;
            printHCodes(ref root.left, arr, top + 1);
        }

        if (root.right != null)
        {
            arr[top] = 1;
            printHCodes(ref root.right, arr, top + 1);
        }
        if (isLeaf(ref root))
        {
            Console.Write(root.item + "  | ");
            printArray(arr, top);
        }
    }

    static void HuffmanCodes(char[] item, int[] freq, int size)
    {
        MinHNode root = buildHfTree(item, freq, size);
        int[] arr = new int[MAX_TREE_HT];
        int top = 0;

        printHCodes(ref root, arr, top);
    }
}
