using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.AbstractFactory.Example
{
    /* Let's implement the Abstract Factory pattern for a GUI application that supports
     * different themes for Windows, macOS, and Linux. Each theme will have its own set of UI components like buttons and text fields.

Step-by-Step Implementation

Define the Abstract Product Interfaces: IButton and ITextField

Implement Concrete Product Classes: WindowsButton, MacButton, LinuxButton, WindowsTextField, MacTextField, LinuxTextField

Create the Abstract Factory Interface: IUIFactory

Implement Concrete Factory Classes: WindowsFactory, MacFactory, LinuxFactory

Client Code: Uses the abstract factory to create theme-specific UI components

1. Define the Abstract Product Interfaces*/
    public interface IButton
    {
        void Render();
    }

    public interface ITextField
    {
        void Render();
    }
    //2. Implement Concrete Product Classes
    public class WindowsButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Windows button.");
        }
    }

    public class MacButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Mac button.");
        }
    }

    public class LinuxButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Linux button.");
        }
    }

    public class WindowsTextField : ITextField
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Windows text field.");
        }
    }

    public class MacTextField : ITextField
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Mac text field.");
        }
    }

    public class LinuxTextField : ITextField
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Linux text field.");
        }
    }
    //3. Create the Abstract Factory Interface
    public interface IUIFactory
    {
        IButton CreateButton();
        ITextField CreateTextField();
    }
    //4. Implement Concrete Factory Classes

    public class WindowsFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton();
        }

        public ITextField CreateTextField()
        {
            return new WindowsTextField();
        }
    }

    public class MacFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new MacButton();
        }

        public ITextField CreateTextField()
        {
            return new MacTextField();
        }
    }

    public class LinuxFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new LinuxButton();
        }

        public ITextField CreateTextField()
        {
            return new LinuxTextField();
        }
    }
    //5. Client Code
    class Application
{
    private readonly IButton _button;
    private readonly ITextField _textField;

    public Application(IUIFactory factory)
    {
        _button = factory.CreateButton();
        _textField = factory.CreateTextField();
    }

    public void RenderUI()
    {
        _button.Render();
        _textField.Render();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IUIFactory factory;

        // Example: Assuming the platform is Windows
        factory = new WindowsFactory();
        Application windowsApp = new Application(factory);
        windowsApp.RenderUI();
        // Output: Rendering a Windows button.
        //         Rendering a Windows text field.

        // Example: Assuming the platform is macOS
        factory = new MacFactory();
        Application macApp = new Application(factory);
        macApp.RenderUI();
        // Output: Rendering a Mac button.
        //         Rendering a Mac text field.

        // Example: Assuming the platform is Linux
        factory = new LinuxFactory();
        Application linuxApp = new Application(factory);
        linuxApp.RenderUI();
        // Output: Rendering a Linux button.
        //         Rendering a Linux text field.
    }
}
    /*Explanation
    Product Interfaces (IButton and ITextField):

    These interfaces define the methods that all concrete product classes must implement.
    Concrete Product Classes (WindowsButton, MacButton, LinuxButton, WindowsTextField, MacTextField, LinuxTextField):

    These classes implement the product interfaces and provide platform-specific behaviors for rendering buttons
    and text fields.
    Abstract Factory Interface (IUIFactory):

    This interface declares methods for creating abstract products (CreateButton and CreateTextField).
    Concrete Factory Classes (WindowsFactory, MacFactory, LinuxFactory):

    These classes implement the factory interface to create specific types of buttons and text fields for each platform.
    Client (Application and Program):

    The client uses an abstract factory to create platform-specific UI components without knowing the concrete classes.
    The Application class takes an IUIFactory instance in its constructor and uses it to create and render the button
    and text field.
    The Program class demonstrates how to create different Application instances for different platforms.
    This implementation allows the application to create and use platform-specific UI components in a
    flexible and maintainable way. New themes or platforms can be added easily by creating new concrete
    product classes and factory classes without changing the existing code.*/
}
