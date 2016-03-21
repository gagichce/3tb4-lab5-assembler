namespace _3tb4_lab5_assembler
{
    public interface IAssemblyInstruction
    {
        byte GetLineMachineCode();
        bool isValidPre();
        bool isValidPost();
    }
}