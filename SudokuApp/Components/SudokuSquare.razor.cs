using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SudokuApp.Components
{
    public enum SquareErrorState
    {
        NotChecked,
        Error,
        Safe
    }

    public partial class SudokuSquare
    {
        [Parameter]
        public EventCallback<MouseEventArgs> Clicked { get; set; }

        [Parameter]
        public int Given { get; set; }

        [Parameter]
        public int Row { get; set; }

        [Parameter]
        public int Column { get; set; }

        [Parameter]
        public int Group { get; set; }

        private int _value;
        private bool _isSelected;
        private SquareErrorState _state;

        public string DisplayValue
        {
            get
            {
                if (Value == 0)
                {
                    return "";
                }
                else
                {
                    return Value.ToString();
                }
            }
        }

        public int Value
        {
            get
            {
                if(Given == 0)
                {
                   
                    return _value;
                }
                else
                {
                    return Given;
                }
            }
            set
            {
                if(Given == 0)
                {
                    this._value = value;
                    this.ErrorState = SquareErrorState.NotChecked;
                    StateHasChanged();
                }
            }
        }

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                this._isSelected = value;
                StateHasChanged();
            }
        }

        public SquareErrorState ErrorState
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                StateHasChanged();
            }
        }

        public static string GetStyle()
        {
            return "width: 75px; height: 75px;";
        }

        public MudBlazor.Color GetColor()
        {
            if (this.IsSelected)
            {
                return MudBlazor.Color.Info;
            }
            else
            {
                return GetStateColor();
            }
            
        }

        public static string GetButtonStyle()
        {
            return "width: 73px; height: 73px;";
        }

        public MudBlazor.Color GetButtonColor()
        {
            return GetStateColor();
        }

        private MudBlazor.Color GetStateColor()
        {
            return this._state switch
            {
                SquareErrorState.NotChecked => MudBlazor.Color.Default,
                SquareErrorState.Error => MudBlazor.Color.Error,
                SquareErrorState.Safe => MudBlazor.Color.Success,
                _ => MudBlazor.Color.Default,
            };
        }

        public static string GetTextStyle()
        {
            return "font-size: 40px;";
        }

        public MudBlazor.Color GetTextColor()
        {
            if (this.Given == 0)
            {
                return MudBlazor.Color.Primary;
            }
            else
            {
                return MudBlazor.Color.Surface;
            }
            
        }

        public async void OnClick(MouseEventArgs args)
        {
            await Clicked.InvokeAsync(args);
            this.IsSelected = !this.IsSelected;
        }

        public void KeyboardEventHandler(KeyboardEventArgs args)
        {
            if (this.IsSelected)
            {
                if(args.Key == "Backspace")
                {
                    this.Value = 0;
                }
                else
                {
                    try
                    {
                        int result = Int32.Parse(args.Key);
                        this.Value = result;
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}
