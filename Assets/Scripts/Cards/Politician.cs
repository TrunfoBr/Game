using System;

[Serializable]
public class Politician {
    public string name;
    public float[] attributes = new float[5];
}

[Serializable]
public class PoliticianArray {
    public int size;
    public Politician[] politicians;

    public int Size {
        get {
            return size;
        }
        set {
            size = value;
            politicians = new Politician[value];
            for (int i = 0; i < size; ++i)
                politicians[i] = new Politician();
        }
    }

    public void ShowContents() {
        string msg = "";
        msg += "Size: " + size.ToString();
        for (int i = 0; i < size; ++i) {
            msg += ", " + politicians[i].name + " [" + politicians[i].attributes[0];
            for (int j = 1; j < 5; ++j)
                msg += "," + politicians[i].attributes[j];
            msg += "]";
        }
        Logger.Log(msg);
    }
}