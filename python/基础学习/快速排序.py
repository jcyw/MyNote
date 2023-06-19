# https://blog.csdn.net/weixin_36755535/article/details/131145158?spm=1000.2115.3001.6382&utm_medium=distribute.pc_feed_v2.none-task-blog-yuanlijihua_tag_v1-2-131145158-null-null.pc_personrec&depth_1-utm_source=distribute.pc_feed_v2.none-task-blog-yuanlijihua_tag_v1-2-131145158-null-null.pc_personrec
def quick_sort(arr):
    """
    快速排序算法的实现函数
    Parameters:
        arr (list): 要排序的数组
    Returns:
        list: 排序后的数组
    """
    # 如果数组长度小于等于1，则直接返回
    if len(arr) <= 1:
        return arr
 
    # 选择基准元素
    pivot = arr[0]
 
    # 分割数组
    left = [x for x in arr[1:] if x <= pivot]
    right = [x for x in arr[1:] if x > pivot]
 
    # 递归调用快速排序算法，并将分割后的数组合并起来
    return quick_sort(left) + [pivot] + quick_sort(right)