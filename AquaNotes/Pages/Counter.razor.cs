using Microsoft.AspNetCore.Components;

namespace AquaNotes.Pages;

public partial class CounterBase : ComponentBase
{
    public int currentCount = 0;

    public void IncrementCount()
    {
        currentCount++;
    }
}
