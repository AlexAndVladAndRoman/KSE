using System;
using UnityEngine;

class Complex {
    public double x, y;

    public Complex(double x, double y) {
        this.x = x;
        this.y = y;
    }

    public static Complex operator *(Complex a, double k) {
        return new Complex(a.x * k, a.y * k);
    }

    public static Complex operator *(Complex a, Complex b) {
        return new Complex(a.x * b.x - a.y * b.y, a.y * b.x + a.x * b.y);
    }

    public static Complex operator +(Complex a, Complex b) {
        return new Complex(a.x * b.x, a.y * b.y);
    }

    // Square distanse between two points
    public static double operator %(Complex a, Complex b) {
        return Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2);
    }

    public Complex z2() {
        return new Complex(Math.Pow(x, 2) - Math.Pow(y, 2), 2.0 * x * y);
    }

    public Complex z3() {
        return new Complex(Math.Pow(x, 3) - 3.0 * x * Math.Pow(y, 2), 3.0 * Math.Pow(x, 2) * y - Math.Pow(y, 3));
    }

    public static explicit operator Vector3(Complex a) {
        return new Vector3((float) a.x, (float) a.y, 1);
    }
}