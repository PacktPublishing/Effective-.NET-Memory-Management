using System;
using System.Runtime.InteropServices;

////static unsafe void UnsafeMethod()
////{
////    int num = 10;
////    int* p = &num;

////    Console.WriteLine("Value: {0}", num);
////    Console.WriteLine("Address: {0:X}", (int)p);
////}


////UnsafeMethod();

//public struct Point
//{
//    public int X;
//    public int Y;
//}

//unsafe
//{
//    Point point = new Point { X = 10, Y = 20 };
//    Point* ptr = &point;
//     // Using the -> operator
//    Console.WriteLine(ptr->X); // Outputs 10
//    Console.WriteLine(ptr->Y); // Outputs 20

//    // Using the * and . operators
//    Console.WriteLine((*ptr).X); // Outputs 10
//    Console.WriteLine((*ptr).Y); // Outputs 20

//    if (ptr == null)
//    {
//      Console.WriteLine("Pointer is null. Cannot dereference.");
//    }
//    else
//    {
//      // Perform pointer related operations
//    }
//}

//int[] numbers = { 1, 2, 3, 4, 5 };

//unsafe
//{
//    fixed (int* ptr = numbers)
//    {
//        for (int i = 0; i < numbers.Length; i++)
//        {
//            Console.WriteLine(ptr[i]);
//        }
//    }
//}

//string text = "Hello, World!";

//unsafe
//{
//    fixed (char* ptr = text)
//    {
//        for (int i = 0; i < text.Length; i++)
//        {
//            Console.WriteLine(ptr[i]);
//        }
//    }
//}


//int[] array1 = { 1, 2, 3 };
//int[] array2 = { 4, 5, 6 };

//unsafe
//{
//    fixed (int* ptr1 = array1)
//    fixed (int* ptr2 = array2)
//    {
//        for (int i = 0; i < array1.Length; i++)
//        {
//            Console.WriteLine($"Array1[{i}] = {ptr1[i]}, Array2[{i}] = {ptr2[i]}");
//        }
//    }
//}


//using System.Runtime.InteropServices;

//// Declare the MessageBox function from user32.dll
////[DllImport("user32.dll", CharSet = CharSet.Auto)]
//static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

//// Call the MessageBox function
//MessageBox(IntPtr.Zero, "Hello, World!", "P/Invoke Example", 0);


//public static class SQLite
//{
//    [DllImport("sqlite3.dll", CallingConvention = CallingConvention.Cdecl)]
//    public static extern int sqlite3_open(string filename, out IntPtr db);

//    [DllImport("sqlite3.dll", CallingConvention = CallingConvention.Cdecl)]
//    public static extern int sqlite3_close(IntPtr db);

//    [DllImport("sqlite3.dll", CallingConvention = CallingConvention.Cdecl)]
//    public static extern int sqlite3_exec(IntPtr db, string sql, IntPtr callback, IntPtr arg, out IntPtr errmsg);
//}

//IntPtr db;
//IntPtr errmsg;

//// Open the database
//if (SQLite.sqlite3_open("test.db", out db) != 0)
//{
//    Console.WriteLine("Failed to open database");
//    return;
//}

//// Execute an SQL statement
//string sql = "CREATE TABLE IF NOT EXISTS Test (Id INTEGER PRIMARY KEY, Name TEXT)";
//if (SQLite.sqlite3_exec(db, sql, IntPtr.Zero, IntPtr.Zero, out errmsg) != 0)
//{
//    Console.WriteLine("Failed to execute SQL: " + Marshal.PtrToStringAnsi(errmsg));
//    SQLite.sqlite3_close(db);
//    return;
//}

//Console.WriteLine("Table created successfully");

//// Close the database
//SQLite.sqlite3_close(db);

//using System.Runtime.InteropServices;

//// Define the callback delegate
//delegate void CallbackDelegate(int value);

//// Import the unmanaged function from the DLL
//[DllImport("callback_example.dll", CallingConvention = CallingConvention.Cdecl)]
//private static extern void ProcessArray(int[] array, int size, CallbackDelegate callback);

//// Define the callback function
//static void MyCallbackFunction(int value)
//{
//    Console.WriteLine("Processing value: " + value);
//}

//static void Main()
//{
//    int[] array = { 1, 2, 3, 4, 5 };

//    // Create an instance of the callback delegate
//    CallbackDelegate callbackDelegate = new CallbackDelegate(MyCallbackFunction);

//    // Call the unmanaged function, passing the array and the callback delegate
//    ProcessArray(array, array.Length, callbackDelegate);

// Define the unmanaged function with the MarshalAs attribute
//using System.Runtime.InteropServices;

//[DllImport("example.dll", CallingConvention = CallingConvention.Cdecl)]
//static extern void UnmanagedFunction(
//    [MarshalAs(UnmanagedType.LPStr)] string str);


//string managedString = "Hello, World!";

//// Call the unmanaged function
//UnmanagedFunction(managedString);


// Import the CreateFile function from kernel32.dll
//[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
//static extern SafeFileHandle CreateFile(
//        string lpFileName,
//        uint dwDesiredAccess,
//        uint dwShareMode,
//        IntPtr lpSecurityAttributes,
//        uint dwCreationDisposition,
//        uint dwFlagsAndAttributes,
//        IntPtr hTemplateFile);

//const uint GENERIC_READ = 0x80000000;
//const uint OPEN_EXISTING = 3;

//// Create a file handle
//SafeFileHandle fileHandle = CreateFile(
//    "example.txt",
//    GENERIC_READ,
//    0,
//    IntPtr.Zero,
//    OPEN_EXISTING,
//    0,
//    IntPtr.Zero);

//if (!fileHandle.IsInvalid)
//{
//    using (FileStream fs = new FileStream(fileHandle, FileAccess.Read))
//    {
//        using (StreamReader reader = new StreamReader(fs))
//        {
//            string content = reader.ReadToEnd();
//            Console.WriteLine(content);
//        }
//    }
//}
//else
//{
//    Console.WriteLine("Failed to open file.");
//}




//[DllImport("SomeUnmanagedLibrary.dll")]
//static extern SafeExampleHandle GetExampleHandle();

//SafeExampleHandle handle = GetExampleHandle();
//if (!handle.IsInvalid)
//{
//    // Use the handle
//    Console.WriteLine("Handle acquired and valid.");

//    // The handle will be released when it goes out of scope and is disposed
//}
//else
//{
//    Console.WriteLine("Failed to acquire handle.");
//}

//public struct ComplexData
//{
//    public int IntData;
//    public string StringData;
//}

//public class ComplexDataMarshaler : ICustomMarshaler
//{
//    public object MarshalNativeToManaged(IntPtr pNativeData)
//    {
//        // Convert native data to managed ComplexData
//        ComplexData data = new ComplexData();
//        data.IntData = Marshal.ReadInt32(pNativeData);
//        IntPtr stringPtr = Marshal.ReadIntPtr(pNativeData, IntPtr.Size);
//        data.StringData = Marshal.PtrToStringAnsi(stringPtr);
//        return data;
//    }

//    public IntPtr MarshalManagedToNative(object ManagedObj)
//    {
//        // Convert managed ComplexData to native data
//        if (!(ManagedObj is ComplexData))
//            throw new ArgumentException("ManagedObj is not of type ComplexData");

//        ComplexData data = (ComplexData)ManagedObj;
//        IntPtr pNativeData = Marshal.AllocHGlobal(IntPtr.Size * 2);
//        Marshal.WriteInt32(pNativeData, data.IntData);
//        IntPtr stringPtr = Marshal.StringToHGlobalAnsi(data.StringData);
//        Marshal.WriteIntPtr(pNativeData, IntPtr.Size, stringPtr);
//        return pNativeData;
//    }

//    public void CleanUpNativeData(IntPtr pNativeData)
//    {
//        // Clean up unmanaged string
//        IntPtr stringPtr = Marshal.ReadIntPtr(pNativeData, IntPtr.Size);
//        Marshal.FreeHGlobal(stringPtr);
//        Marshal.FreeHGlobal(pNativeData);
//    }

//    public int GetNativeDataSize()
//    {
//        return IntPtr.Size * 2;
//    }

//    public static ICustomMarshaler GetInstance(string cookie)
//    {
//        return new ComplexDataMarshaler();
//    }

//    public void CleanUpManagedData(object ManagedObj)
//    {
//        throw new NotImplementedException();
//    }
//}

//// Using the custom marshaler
//[DllImport("SomeUnmanagedLibrary.dll")]
//public static extern void ProcessComplexData([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ComplexDataMarshaler))] ComplexData data);


//ComplexData data = new ComplexData { IntData = 42, StringData = "Hello, World!" };
//ProcessComplexData(data);



namespace ConsoleApp.Chapter07;



static class Program
{
    // Define a simple structure
    [StructLayout(LayoutKind.Sequential)]
    public struct MyStruct
    {
        public int x;
        public double y;
    }

    // Simulated unmanaged function 
    [DllImport("NativeLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnmanagedFunction(IntPtr ptr);

    static void Main()
    {
        MyStruct myStruct = new MyStruct
        {
            x = 42,
            y = 3.14
        };

        // Allocate unmanaged memory for the structure
        IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(myStruct));

        try
        {
            // Convert the structure to a pointer
            Marshal.StructureToPtr(myStruct, ptr, false);
    
            // Call the unmanaged function with the pointer
            UnmanagedFunction(ptr);
        }
        finally
        {
            // Free the unmanaged memory
            Marshal.FreeHGlobal(ptr);
        }

    }
}
