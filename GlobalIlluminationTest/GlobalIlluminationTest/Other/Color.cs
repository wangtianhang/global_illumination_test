﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    struct Color
    {
        public float r;
        public float g;
        public float b;
        public float a;
        public Color(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = 1;
        }

        public Color(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public static Color red
        {
            get
            {
                return new Color(1f, 0f, 0f, 1f);
            }
        }

        public static Color green
        {
            get
            {
                return new Color(0f, 1f, 0f, 1f);
            }
        }

        public static Color blue
        {
            get
            {
                return new Color(0f, 0f, 1f, 1f);
            }
        }

        public static Color white
        {
            get
            {
                return new Color(1f, 1f, 1f, 1f);
            }
        }

        public static Color black
        {
            get
            {
                return new Color(0f, 0f, 0f, 1f);
            }
        }

        public static Color yellow
        {
            get
            {
                return new Color(1f, 0.921568632f, 0.0156862754f, 1f);
            }
        }

        public static Color cyan
        {
            get
            {
                return new Color(0f, 1f, 1f, 1f);
            }
        }

        public static Color magenta
        {
            get
            {
                return new Color(1f, 0f, 1f, 1f);
            }
        }

        public static Color gray
        {
            get
            {
                return new Color(0.5f, 0.5f, 0.5f, 1f);
            }
        }

        public static Color grey
        {
            get
            {
                return new Color(0.5f, 0.5f, 0.5f, 1f);
            }
        }

        public static Color clear
        {
            get
            {
                return new Color(0f, 0f, 0f, 0f);
            }
        }

        public float grayscale
        {
            get
            {
                return 0.299f * this.r + 0.587f * this.g + 0.114f * this.b;
            }
        }

        public static Color Lerp(Color a, Color b, float t)
        {
            t = Mathf.Clamp01(t);
            return new Color(a.r + (b.r - a.r) * t, a.g + (b.g - a.g) * t, a.b + (b.b - a.b) * t, a.a + (b.a - a.a) * t);
        }

        public static Color operator +(Color a, Color b)
        {
            return new Color(a.r + b.r, a.g + b.g, a.b + b.b, a.a + b.a);
        }

        public static Color operator -(Color a, Color b)
        {
            return new Color(a.r - b.r, a.g - b.g, a.b - b.b, a.a - b.a);
        }

        public static Color operator *(Color a, Color b)
        {
            return new Color(a.r * b.r, a.g * b.g, a.b * b.b, a.a * b.a);
        }

        public static Color operator *(Color a, float b)
        {
            return new Color(a.r * b, a.g * b, a.b * b, a.a * b);
        }

        public static Color operator *(float b, Color a)
        {
            return new Color(a.r * b, a.g * b, a.b * b, a.a * b);
        }

        public static Color operator /(Color a, float b)
        {
            return new Color(a.r / b, a.g / b, a.b / b, a.a / b);
        }

        public static bool operator ==(Color lhs, Color rhs)
        {
            return lhs == rhs;
        }

        public static bool operator !=(Color lhs, Color rhs)
        {
            return lhs != rhs;
        }

        public static implicit operator Vector4(Color c)
        {
            return new Vector4(c.r, c.g, c.b, c.a);
        }

        public static implicit operator Color(Vector4 v)
        {
            return new Color(v.x, v.y, v.z, v.w);
        }
    }
}

