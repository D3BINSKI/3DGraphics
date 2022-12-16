namespace WinFormsApp.GeometryComponents;

public class Face
{
    private List<Vertex> _vertices;
    private readonly List<Edge> _edges;

    public List<Vertex> Vertices => _vertices;
    public List<Edge> Edges => _edges;

    public Face(List<Vertex> vertices)
    {
        _vertices = vertices;
        _edges = new List<Edge>
        {
            new(_vertices[0], _vertices[1]),
            new(_vertices[1], _vertices[2]),
            new(_vertices[2], _vertices[0])
        };
    }
}