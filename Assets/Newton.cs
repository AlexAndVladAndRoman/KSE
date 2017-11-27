using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Newton : MonoBehaviour {
    private LineRenderer line;

    public int Aproximation = 10;
    public double Scale = 1.5;
    public int Parts = 10;

    // Use this for initialization
    void Start() {
        line = GetComponent<LineRenderer>();

//        line.positionCount = 5;
//        line.SetPositions(new Vector3[5] {new Vector3(0, 0, 1), new Vector3(0, 1, 1), new Vector3(1, 1, 1), new Vector3(2, -1, 1), new Vector3(3, -1, 1)});
    }

    // Update is called once per frame
    void Update() {
        var tmp = new Complex(0.0, 0.0);
        var b = new Complex(-Scale, -Scale);
        for (var i = 0; i < Parts; i++) {
            tmp.x = b.x + 2.0 * Scale * i / Parts;
            for (var j = 0; j < Parts; j++) {
                tmp.y = b.y + 2.0 * Scale * j / Parts;
                line.SetPositions(Calc(tmp).Select(x => (Vector3) x).ToArray());
            }
        }
    }

    private List<Complex> Calc(Complex number) {
        var nearness = new List<Complex> {number};

        for (var i = 1; i < Aproximation; i++) {
            var prev = nearness[i - 1];

            var z3 = prev.z3();
            var z2 = prev.z2();

            z3 *= 2.0;
            z3.x += 1;

            var nz2 = new Complex(z2.x, -z2.y);
            z3 *= nz2;
            z2 *= 3.0;
            z2 *= nz2;

            nearness.Add(z3 * (1 / z2.x));
        }

        return nearness;
    }
}