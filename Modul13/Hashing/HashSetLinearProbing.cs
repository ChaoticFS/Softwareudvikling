using Hashing;

public class HashSetLinearProbing : HashSet {
    private Object[] buckets;
    private int currentSize;
    private enum State { DELETED }

    public HashSetLinearProbing(int bucketsLength) {
        buckets = new Object[bucketsLength];
        currentSize = 0;
    }

    public bool Contains(Object x) {
        int h = HashValue(x);
        int index = h;

        while (buckets[index] != null)
        {
            if (buckets[index].Equals(x))
            {
                return true;
            }

            index = (index + 1) % buckets.Length;
            if (index == h)
            {
                break;
            }
        }

        return false;
    }

    public bool Add(Object x) {
        if (Contains(x))
        {
            return false;
        }

        int h = HashValue(x);
        int index = h;
        int count = 0;

        while (buckets[index] != null && !buckets[index].Equals(State.DELETED))
        {
            index = (index + 1) % buckets.Length;
            count++;
            if (buckets.Length == count)
            {
                return false;
            }
        }

        buckets[index] = x;
        currentSize++;

        return true;
    }

    public bool Remove(Object x) {
        int h = HashValue(x);
        int index = h;

        while (buckets[index] != null)
        {
            if (buckets[index].Equals(x))
            {
                buckets[index] = State.DELETED;
                currentSize--;
                return true;
            }

            index = (index + 1) % buckets.Length;
            if (index == h)
            {
                break;
            }
        }

        return false;
    }

    public int Size() {
        return currentSize;
    }

    private int HashValue(Object x) {
        int h = x.GetHashCode();
        if (h < 0) {
            h = -h;
        }
        h = h % buckets.Length;
        return h;
    }

    public override String ToString() {
        String result = "";
        for (int i = 0; i < buckets.Length; i++) {
            int value = buckets[i] != null && !buckets[i].Equals(State.DELETED) ? 
                    HashValue(buckets[i]) : -1;
            result += i + "\t" + buckets[i] + "(h:" + value + ")\n";
        }
        return result;
    }

}
