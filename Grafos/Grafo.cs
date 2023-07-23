namespace pontinhos.Grafos
{
    public class Grafo
    {
        public Random _rng;
        public int[][] MatrizAdjacencias { get; set; }
        public Vertice[] Vertices { get; set; }

        public Grafo(int vertices)
        {
            _rng = new Random();
            MatrizAdjacencias = new int[vertices][];
            Vertices = new Vertice[vertices];

            for (int i = 0; i < vertices; i++)
            {
                MatrizAdjacencias[i] = new int[vertices];

                for (int j = 0; j < vertices; j++)
                    MatrizAdjacencias[i][j] = 0;

                Vertices[i] = new Vertice(
                        x: _rng.Next(Constantes.LarguraDoCanva - Constantes.LarguraDosVertices),
                        y: _rng.Next(Constantes.AlturaDoCanva - Constantes.LarguraDosVertices));
            }

            int arestas = vertices * 2;
            for (int i = 0; i < arestas; i++)
                ConectarDoisPontos(_rng.Next(vertices - 1), _rng.Next(vertices - 1));

            //se houver algum vertice sem aresta,
            //vou conecta-lo com um vértice random, 
            //assim os desenhos ficam mais bonitinhos :)
            GarantirQueOGrafoEstaConexo();
        }

        public void ConectarDoisPontos(int ponto1, int ponto2)
        {
            if (ponto1 == ponto2)
                return;

            if (MatrizAdjacencias[ponto2][ponto1] == 1)
                return;

            MatrizAdjacencias[ponto1][ponto2] = 1;
        }

        public void GarantirQueOGrafoEstaConexo()
        {
            for (int i = 0; i < Vertices.Length; i++)
            {
                var iConectado = false;

                for (int j = 0; j < Vertices.Length; j++)
                {
                    if (MatrizAdjacencias[i][j] == 1)
                    {
                        iConectado = true;
                        break;
                    }
                }

                if (iConectado)
                    continue;

                MatrizAdjacencias[i][_rng.Next(Vertices.Length - 1)] = 1;
            }
        }
    }
}
