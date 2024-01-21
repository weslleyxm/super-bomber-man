using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] StageSettings settings;

    private Node[,] nodes;

    void Start()
    {
        nodes = new Node[settings.column, settings.row];

        Transform blockParent = new GameObject("blocks").transform;
        Transform destructibleParent = new GameObject("destructibleParent").transform;

        blockParent.SetParent(transform);
        destructibleParent.SetParent(transform);

        for (int i = 0; i < settings.column; i++)
        {
            for (int j = 0; j < settings.row; j++)
            {
                if (j <= 1 || j >= settings.row - 2 || i <= 1 || i >= settings.column - 2)
                {
                    CreateBlock(i, j, settings.borderBlock, blockParent);
                }
                else if (j % 2 != 0 && i % 2 != 0)
                {
                    CreateBlock(i, j, settings.solidBlock, blockParent);
                }
                else
                {
                    CreateBlock(i, j, settings.floorBlock, blockParent);

                    if (Random.value <= .8f && !settings.forbiddenDestructiblePositions.Contains(new Coord(i, j)))
                    {
                        CreateBlock(i, j, settings.destructibleBlock, destructibleParent);
                    }
                }

                nodes[i, j] = new Node
                {
                    coordinates = new Coord(i, j)
                };
            }
        }
    }

    private GameObject CreateBlock(int i, int j, Sprite sprite, Transform parent)
    {
        var block = new GameObject($"block ({i}, {j})").AddComponent<SpriteRenderer>();
        block.transform.position = new Vector2(settings.blockSpacing * i, settings.blockSpacing * j);
        block.transform.SetParent(parent);
        block.sprite = sprite;
        return block.gameObject;
    } 
}
