using System.Collections.Generic;

public class SmoothQueue
{
  private Queue<float> queue;
  private float sum = 0;
  private int smoothing;
  public SmoothQueue(int smoothness)
  {
    queue = new Queue<float>(smoothness);
    smoothing = smoothness;
  }
  // Continuous average calculation via FIFO queue
  // Saves us iterating every time we update, we just change by the delta
  public float Enqueue(float newVal)
  {
    // Generate random new item, calculate new average
    queue.Enqueue(newVal);
    sum += newVal;
    // pop off an item if too big
    while (queue.Count >= smoothing)
    {
      sum -= queue.Dequeue();
    }
    return sum / (float)queue.Count;
  }
}