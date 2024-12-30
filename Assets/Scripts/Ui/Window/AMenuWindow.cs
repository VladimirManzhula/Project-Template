using Reflex;
using ReflexUI.Runtime;
using ReflexUI.Runtime.Interfaces;
using UnityEngine;

namespace Ui.Window
{
    public abstract class AMenuWindow : WindowBase
    {
    }

    public interface IMenuWindowController : IWindowsController<AMenuWindow>
    {
    }

    public class MenuWindowController : WindowsController<AMenuWindow>, IMenuWindowController
    {
        public MenuWindowController(Container container, Transform canvasTransform) : base(container, canvasTransform)
        {
        }
    }
}