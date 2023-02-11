// 给你一个二叉树的根节点 root ， 检查它是否轴对称。
// 示例 1：
// 输入：root = [1,2,2,3,4,4,3]
// 输出：true
using namespace std;

struct TreeNode {
    int val;
    TreeNode *left;
    TreeNode *right;
//  TreeNode() : val(0), left(nullptr), right(nullptr) {}
//  TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
//  TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
};

bool IsIsSymmetryTree(TreeNode* root)
{
    return IsSymmetry(root , root);
}

bool IsSymmetry(TreeNode* node1, TreeNode* node2)
{
    if(!node1 && !node2)
        return false;
    if(!node1 || !node2)
        return false;
    if(node1->val == node2->val)
        return IsSymmetry(node1->left, node2->right) && IsSymmetry(node1->right, node2->left);
    return false;

}

int main()
{

}