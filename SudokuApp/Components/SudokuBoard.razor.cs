using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SudokuApp.Components
{
    public partial class SudokuBoard
    {
        [Parameter]
        public string Givens { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public SudokuSquare[][] sudokuSquares;
    }
}