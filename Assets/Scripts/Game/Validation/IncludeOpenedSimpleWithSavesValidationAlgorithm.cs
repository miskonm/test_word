namespace TW.Game.Validation
{
    public class IncludeOpenedSimpleWithSavesValidationAlgorithm : SimpleWithSavesValidationAlgorithm
    {
        protected override bool NeedIncludeOpenedWorlds => true;
    }
}