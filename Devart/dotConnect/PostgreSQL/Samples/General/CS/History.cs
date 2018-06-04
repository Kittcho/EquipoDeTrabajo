using System;
using System.Collections;

namespace Samples
{
  /// <summary>
  /// Summary description for History.
  /// </summary>

  public class History {

    private int position = -1;
    private readonly int size;

    private ArrayList historyList;

    public History(int visibleSize) {

      size = visibleSize;
      historyList = new ArrayList(visibleSize);
    }

    public void Back() {

      BackTo(1);
    }

    public void BackTo(int offset) {
      
      Navigate(-offset);
    }

    public void Forward() {

      ForwardTo(1);
    }

    public void ForwardTo(int offset) {
      
      Navigate(offset);
    }

    public void Add(object item) {

      if (this.position < historyList.Count - 1) {
        int indexRemove = position + 1;
        historyList.RemoveRange(indexRemove, historyList.Count - indexRemove);
      }

      historyList.Add(item);
      position++;

      OnHistoryChanged(this);
    }

    private void OnHistoryChanged(History sender) {

      if (HistoryChanged != null)
        HistoryChanged(this);
    }

    private void Navigate(int i){

      position += i;
      OnHistoryChanged(this);
    }

    public event HistoryChangedHandler HistoryChanged;

    public ICollection BackList {
      get {
        object[] result;

        if (position < size) {
          result = new object[position];
          historyList.CopyTo(0, result, 0, position);
        }
        else {
          result = new object[size];
          historyList.CopyTo(position - size, result, 0, size);
        }
        return result;
      }
    }

    public ICollection ForwardList {
      get {
        int forwardSize = historyList.Count - position - 1;
        if (forwardSize == 0)
          return new object[0];

        if (forwardSize > size)
          forwardSize = size;

        object[] result = new object[forwardSize];
        historyList.CopyTo(position + 1, result, 0, forwardSize);

        Array.Reverse(result);
        return result;
      }
    }

    public object Current {
      get {
        return historyList[position];
      }
    }
  }

  public delegate void HistoryChangedHandler(History sender);
}