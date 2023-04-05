namespace TW.Game.Validation
{
    public class NotIncludeOpenedSimpleWithSavesValidationAlgorithm : SimpleWithSavesValidationAlgorithm
    {
        protected override bool NeedIncludeOpenedWorlds => false;
    }
}