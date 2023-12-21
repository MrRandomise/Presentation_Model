using Lessons.Architecture.PM;

public interface IButton<CharacterManager, CharacterUpdate>
{
    void InitializeButtons(CharacterManager characterManager, CharacterUpdate CharacterUpdate);
}
