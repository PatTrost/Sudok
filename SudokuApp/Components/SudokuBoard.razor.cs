using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using MudBlazor;

namespace SudokuApp.Components
{
    public partial class SudokuBoard
    {
        [Parameter]
        public string Givens { get; set; }
        [Parameter]
        public int Width { get; set; }
        [Parameter]
        public int Height { get; set; }
        private bool Initialised { get; set; }

        public List<SudokuSquare> sudokuSquares;

        protected override async Task OnInitializedAsync()
        {
            if (!this.Initialised)
            {
                sudokuSquares = new List<SudokuSquare>();
                for (int i = 0; i < (this.Width * this.Height); i++)
                {
                    sudokuSquares.Add(new SudokuSquare());
                }
                this.Initialised = true;
            }
        }

        public void KeyboardEventHandler(KeyboardEventArgs args)
        {
            foreach (SudokuSquare square in sudokuSquares)
            {
                if (square.IsSelected)
                {
                    square.KeyboardEventHandler(args);
                }
            }
        }

        
    }
}