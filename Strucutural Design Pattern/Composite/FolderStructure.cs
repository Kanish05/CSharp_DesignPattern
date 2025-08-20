using System;
using System.Collections.Generic;

// Component: Common interface for both files and folders
public abstract class FileSystemComponent
{
    protected string name;
    
    public FileSystemComponent(string name)
    {
        this.name = name;
    }
    
    // Common operations that both files and folders can perform
    public abstract void Display(int depth = 0);
    public abstract long GetSize();
    
    // These operations only make sense for composites (folders)
    // Default implementation throws exception for leaves (files)
    public virtual void Add(FileSystemComponent component)
    {
        throw new NotSupportedException("Cannot add to a file");
    }
    
    public virtual void Remove(FileSystemComponent component)
    {
        throw new NotSupportedException("Cannot remove from a file");
    }
    
    public virtual FileSystemComponent GetChild(int index)
    {
        throw new NotSupportedException("Files don't have children");
    }
}

// Leaf: Individual files that cannot contain other components
public class File : FileSystemComponent
{
    private long size;
    
    public File(string name, long size) : base(name)
    {
        this.size = size;
    }
    
    public override void Display(int depth = 0)
    {
        Console.WriteLine(new string('-', depth) + " File: " + name + " (" + size + " bytes)");
    }
    
    public override long GetSize()
    {
        return size;
    }
}

// Composite: Folders that can contain other files and folders
public class Folder : FileSystemComponent
{
    private List<FileSystemComponent> children = new List<FileSystemComponent>();
    
    public Folder(string name) : base(name)
    {
    }
    
    public override void Add(FileSystemComponent component)
    {
        children.Add(component);
    }
    
    public override void Remove(FileSystemComponent component)
    {
        children.Remove(component);
    }
    
    public override FileSystemComponent GetChild(int index)
    {
        return children[index];
    }
    
    public override void Display(int depth = 0)
    {
        Console.WriteLine(new string('-', depth) + " Folder: " + name);
        
        // Recursively display all children
        foreach (var child in children)
        {
            child.Display(depth + 2);
        }
    }
    
    public override long GetSize()
    {
        long totalSize = 0;
        
        // Sum up sizes of all children
        foreach (var child in children)
        {
            totalSize += child.GetSize();
        }
        
        return totalSize;
    }
    
    public int GetChildCount()
    {
        return children.Count;
    }
}

// Client code demonstrating the pattern
public class Program
{
    public static void Main()
    {
        Console.WriteLine("=== Composite Pattern Demo: File System ===\n");
        
        // Create individual files (leaves)
        File file1 = new File("document.txt", 1024);
        File file2 = new File("image.jpg", 2048);
        File file3 = new File("video.mp4", 5120);
        File file4 = new File("readme.md", 512);
        
        // Create folders (composites)
        Folder rootFolder = new Folder("My Documents");
        Folder picturesFolder = new Folder("Pictures");
        Folder videosFolder = new Folder("Videos");
        
        // Build the tree structure
        rootFolder.Add(file1); // Add file directly to root
        rootFolder.Add(file4); // Add another file to root
        
        picturesFolder.Add(file2); // Add file to pictures folder
        videosFolder.Add(file3);   // Add file to videos folder
        
        // Add folders to root folder (composites containing composites)
        rootFolder.Add(picturesFolder);
        rootFolder.Add(videosFolder);
        
        // Create a nested structure
        Folder subFolder = new Folder("Vacation Photos");
        subFolder.Add(new File("beach.jpg", 1536));
        subFolder.Add(new File("mountain.jpg", 1792));
        picturesFolder.Add(subFolder);
        
        // Display the entire structure
        Console.WriteLine("File System Structure:");
        rootFolder.Display();
        
        Console.WriteLine("\n" + new string('=', 50));
        
        // Demonstrate uniform treatment - we can call GetSize() on any component
        Console.WriteLine($"Total size of root folder: {rootFolder.GetSize()} bytes");
        Console.WriteLine($"Size of pictures folder: {picturesFolder.GetSize()} bytes");
        Console.WriteLine($"Size of single file: {file1.GetSize()} bytes");
        
        Console.WriteLine("\n" + new string('=', 50));
        
        // Show that we can treat individual files and folders the same way
        List<FileSystemComponent> components = new List<FileSystemComponent>
        {
            file1,           // Individual files
            picturesFolder,  // Folder with contents
            videosFolder     // Another folder //
        };
        
        Console.WriteLine("Treating different components uniformly:");
        foreach (var component in components)
        {
            Console.WriteLine($"Component size: {component.GetSize()} bytes");
        }
    }
}

