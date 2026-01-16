using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleNormal
{
    internal class Program
    {
        static void CalculateTriangleNormal(
            float Ax, float Ay, float Az,
            float Bx, float By, float Bz,
            float Cx, float Cy, float Cz,
            out float nx, out float ny, out float nz)
        {
            float ux = Bx - Ax;
            float uy = By - Ay;
            float uz = Bz - Az;

            float vx = Cx - Ax;
            float vy = Cy - Ay;
            float vz = Cz - Az;

            nx = uy * vz - uz * vy;
            ny = uz * vx - ux * vz;
            nz = ux * vy - uy * vx;

            float length = (float)Math.Sqrt(nx * nx + ny * ny + nz * nz);
            if(length != 0)
            {
                nx /= length;
                ny /= length;
                nz /= length;
            }
        }
        static void Main(string[] args)
        {
            float Ax = 0, Ay = 0, Az = 0;
            float Bx = 1, By = 0, Bz = 0;
            float Cx = 0, Cy = 1, Cz = 0;

            float nx, ny, nz;
            CalculateTriangleNormal(Ax, Ay, Az, Bx, By, Bz, Cx, Cy, Cz, out nx, out ny, out nz);
            Console.WriteLine($"Normala triunghiului: X = {nx}, Y = {ny}, Z = {nz}");
        }
    }
}
