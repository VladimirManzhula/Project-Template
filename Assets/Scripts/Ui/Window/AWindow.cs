using Reflex;
using ReflexUI.Runtime;
using ReflexUI.Runtime.Interfaces;
using UnityEngine;

namespace Ui.Window
{
    public abstract class AWindow : WindowBase
    {
    }

    public interface ISimpleWindowController : IWindowsController<AWindow>
    {
    }

    public class SimpleWindowController : WindowsController<AWindow>, ISimpleWindowController
    {
        public SimpleWindowController(Container container, Transform canvasTransform) : base(container, canvasTransform)
        {
        }
    }
}