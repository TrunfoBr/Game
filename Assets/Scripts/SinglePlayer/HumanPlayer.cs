public class HumanPlayer : SinglePlayer {

    public void SelectAttribute(int attribute) {
        if (turn) {
            attributeToPlay = attribute;
            hasDecidedAttribute = true;
            Logger.Log(this, "SelectAttribute", "Selected attribute: " + attribute.ToString());
        }
    }
}
