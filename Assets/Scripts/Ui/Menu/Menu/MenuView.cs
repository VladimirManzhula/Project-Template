using ReflexUI.Runtime.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Menu.Menu
{
    public class MenuView : UiView
    {
        [SerializeField] private Button startGameButton;
        
        public Button StartGameButton => startGameButton;
    }
}