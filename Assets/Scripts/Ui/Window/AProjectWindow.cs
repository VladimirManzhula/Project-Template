using Reflex;
using ReflexUI.Runtime;
using ReflexUI.Runtime.Interfaces;
using UnityEngine;

namespace Ui.Window
{
    public abstract class AProjectWindow : WindowBase
    {
    }
    
    public interface IProjectWindowController : IWindowsController<AProjectWindow>
    {
    }

    public class ProjectWindowController : WindowsController<AProjectWindow>, IProjectWindowController
    {
        public ProjectWindowController(Container container, Transform canvasTransform) : base(container, canvasTransform)
        {
        }
    }
}