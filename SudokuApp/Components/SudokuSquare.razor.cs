using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SudokuApp.Components
{
    public partial class SudokuSquare
    {
        private int _value;
        private bool _isSelected;

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
            }
        }

        [Parameter]
        public int Given { get; set; }

        public static string GetStyle()
        {

            return "width: 75px; height: 75px;";
        }

        public MudBlazor.Color GetColor()
        {
            if (this.IsSelected)
            {
                return MudBlazor.Color.Primary;
            }
            else
            {
                return MudBlazor.Color.Default;
            }
            
        }

        public void OnClick()
        {
            this.IsSelected = !this.IsSelected;
        }

        public void KeyboardEventHandler(KeyboardEventArgs args)
        {
            if (this.IsSelected)
            {
                try
                {
                    int result = Int32.Parse(args.Key);
                    this.Value = result;
                    StateHasChanged();
                }
                catch
                {

                }
            }
        }
    }
}
