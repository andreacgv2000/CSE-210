public class Comment
{
    private string _commenterName;
    private string _commentText;
    private bool _isHidden;

    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
        _isHidden = false; // por defecto no está oculto
    }

    public string GetCommenterName()
    {
        return _commenterName;
    }

    public string GetCommentText()
    {
        return _isHidden ? new string('*', _commentText.Length) : _commentText;
    }

    public void HideComment()
    {
        _isHidden = true;
    }

    public void RevealComment()
    {
        _isHidden = false;
    }
}
