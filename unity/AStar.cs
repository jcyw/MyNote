// 以下是C#实现的A*算法示例代码：

using System.Collections.Generic;

public class AStarNode
{
    public int x;
    public int y;
    public int g; // 从起点到当前节点的实际代价（即移动代价或步数）
    public int h; // 预计从当前节点到目标节点的代价（即启发式估价）
    public int f; // 总代价：f = g + h
    public AStarNode parent; // 上一个节点

    public AStarNode(int x, int y)
    {
        this.x = x;
        this.y = y;
        this.g = 0;
        this.h = 0;
        this.f = 0;
        this.parent = null;
    }
}

public class AStar
{
    private int[,] map; // 地图
    private List<AStarNode> openList = new List<AStarNode>(); // 开放列表
    private List<AStarNode> closedList = new List<AStarNode>(); // 关闭列表
    private int start_x; // 起点坐标x
    private int start_y; // 起点坐标y
    private int end_x; // 终点坐标x
    private int end_y; // 终点坐标y

    public AStar(int[,] map)
    {
        this.map = map;
    }

    // 启发式估价函数：曼哈顿距离
    private int heuristic(int x1, int y1, int x2, int y2)
    {
        return Mathf.Abs(x1 - x2) + Mathf.Abs(y1 - y2);
    }

    // 获取开放列表中f值最小的节点
    private AStarNode getMinimumFNode()
    {
        int minF = int.MaxValue;
        AStarNode minFNode = null;
        foreach (AStarNode node in openList)
        {
            if (node.f < minF)
            {
                minF = node.f;
                minFNode = node;
            }
        }
        return minFNode;
    }

    // 获取一个节点周围可到达的节点
    private List<AStarNode> getAdjacentNodes(AStarNode node)
    {
        List<AStarNode> adjacentNodes = new List<AStarNode>();
        int x = node.x;
        int y = node.y;
        // 上
        if (y > 0 && map[x, y - 1] == 0)
        {
            adjacentNodes.Add(new AStarNode(x, y - 1));
        }
        // 下
        if (y < map.GetLength(1) - 1 && map[x, y + 1] == 0)
        {
            adjacentNodes.Add(new AStarNode(x, y + 1));
        }
        // 左
        if (x > 0 && map[x - 1, y] == 0)
        {
            adjacentNodes.Add(new AStarNode(x - 1, y));
        }
        // 右
        if (x < map.GetLength(0) - 1 && map[x + 1, y] == 0)
        {
            adjacentNodes.Add(new AStarNode(x + 1, y));
        }
        return adjacentNodes;
    }

    // 计算节点的总代价f值
    private void calculateFValue(AStarNode node)
    {
        node.g = node.parent.g + 1;
        node.h = heuristic(node.x, node.y, end_x, end_y);
        node.f = node.g + node.h;
    }

    // 搜索路径
    public List<AStarNode> searchPath(int start_x, int start_y, int end_x, int end_y)
    {
        this.start_x = start_x;
        this.start_y = start_y;
        this.end_x = end_x;
        this.end_y = end_y;
        AStarNode startNode = new AStarNode(start_x, start_y);
        openList.Add(startNode);
        while (openList.Count > 0)
        {
            AStarNode current = getMinimumFNode();
            openList.Remove(current);
            closedList.Add(current);
            if (current.x == end_x && current.y == end_y)
            {
                // 找到路径
                List<AStarNode> path = new List<AStarNode>();
                path.Add(current);
                while (current.parent != null)
                {
                    path.Add(current.parent);
                    current = current.parent;
                }
                path.Reverse();
                return path;
            }
            List<AStarNode> adjacentNodes = getAdjacentNodes(current);
            foreach (AStarNode adjacentNode in adjacentNodes)
            {
                if (!closedList.Contains(adjacentNode))
                {
                    if (!openList.Contains(adjacentNode))
                    {
                        adjacentNode.parent = current;
                        calculateFValue(adjacentNode);
                        openList.Add(adjacentNode);
                    }
                    else
                    {
                        int newGValue = current.g + 1;
                        if (newGValue < adjacentNode.g)
                        {
                            adjacentNode.g = newGValue;
                            adjacentNode.f = adjacentNode.g + adjacentNode.h;
                            adjacentNode.parent = current;
                        }
                    }
                }
            }
        }
        // 没有找到路径
        return null;
    }
}

// 使用示例：

// 创建一个地图（0表示可行，1表示障碍）
int[,] map = new int[,] {
    { 0, 1, 0, 0 },
    { 0, 1, 0, 0 },
    { 0, 1, 0, 0 },
    { 0, 0, 0, 0 }
};

// 创建AStar实例
AStar aStar = new AStar(map);

// 搜索路径（从(0,0)到(3,3)）
List<AStarNode> path = aStar.searchPath(0, 0, 3, 3);

// 输出路径
if (path != null)
{
    foreach (AStarNode node in path)
    {
        Debug.Log(node.x + "," + node.y);
    }
}
else
{
    Debug.Log("找不到路径！");
}