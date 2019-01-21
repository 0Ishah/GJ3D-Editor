/*   Project Name: GJ3D Editor
 *   File Name: Mesh.cs
 *   Author: Ilya Fedin
 *   Date Created: Fri, Jan 18, 2018
 *   Date Modeified: Sun, Jan 10, 2018
 *   File Description: Mesh class containing the basic information about the meshes shuch as vertices and faces
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJ3Editor
{
    public class Mesh
    {
        private List<Vector3> verticesData; //Verticses are given as vector3 of coordinates
        private List<Vector3i> facesData; //Faces are given as vecotr3 of indices of vertices For example (0,1,2) would represent a triangel with coordinates verticiesData[0],verticiesData[1],verticiesData[2]

        /// <summary>
        /// Default constructor creating a cube
        /// </summary>
        public Mesh()
        {
            verticesData = Data.Cube.verticesData;
            facesData = Data.Cube.facesData;
        }
        /// <summary>
        /// Constructor allowng to creare a custom new mesh
        /// </summary>
        /// <param name="vertices">List of vertices</param>
        /// <param name="faces">List of indexes of faces</param>
        public Mesh(List<Vector3> vertices, List<Vector3i> faces)
        {
            verticesData = vertices;
            facesData = faces;
        }

        public List<Vector3> GetVertices()
        {
            return verticesData;
        }
        public List<Vector3i> GetFaces()
        {
            return facesData;
        }
    }
}
