/*   Project Name: GJ3D Editor
 *   File Name: Data.cs
 *   Author: Ilya Fedin
 *   Date Created: Fri, Jan 18, 2018
 *   Date Modeified: Sun, Jan 10, 2018
 *   File Description: Data class for holding information about meshes
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJ3Editor
{
    public static class Data
    {
        public static readonly Mesh Plane = new Mesh(
            new List<Vector3>(){
                new Vector3( -100, -100, 100),
                new Vector3( -100, 100, 100),
                new Vector3( 100, 100, 100),
                new Vector3( 100, -100, 100)},
            new List<Vector3i>(){
                new Vector3i(0, 1, 2),
                new Vector3i(0, 2, 3)});

        public static readonly Mesh Pyramid = new Mesh(
            new List<Vector3>(){
                new Vector3( -100, -100, -100),
                new Vector3( 100, -100, -100),
                new Vector3( 0, 100, 0),
                new Vector3( 0, -100, 100)},
            new List<Vector3i>(){
                new Vector3i(0, 1, 2),
                new Vector3i(2, 1, 3),
                new Vector3i(3, 1, 0),
                new Vector3i(0, 3, 2)});

        public static readonly Mesh Cube = new Mesh(
            new List<Vector3>(){
                new Vector3(0,0,0),
                new Vector3(0,100,0),
                new Vector3(100,100,0),
                new Vector3(100,0,0),
                new Vector3(100,100,100),
                new Vector3(100,0,100),
                new Vector3(0,100,100),
                new Vector3(0,0,100)},
            new List<Vector3i>(){
                new Vector3i(0,1,2),
                new Vector3i(0,2,3),
                new Vector3i(3,2,4),
                new Vector3i(3,4,5),
                new Vector3i(5,4,6),
                new Vector3i(5,6,7),
                new Vector3i(7,6,1),
                new Vector3i(7,1,0),
                new Vector3i(1,6,4),
                new Vector3i(1,4,2),
                new Vector3i(7,0,3),
                new Vector3i(7,3,5)});
    }
}
                