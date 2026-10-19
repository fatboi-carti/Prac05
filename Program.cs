using System.Formats.Asn1;

int elementCount = 8_000_000;
int stepCount = 4;
int bytesPerElement = 4;
double bytesPerMiB = 1024.0 * 1024;
List<int[]> blocks = new List<int[]>();

long startMemory = Environment.WorkingSet;
System.Console.WriteLine($"Шаг 0. Рабочий набор: {startMemory / bytesPerMiB:F2} MiB");

for (int step = 1; step < stepCount; step++)
{
    System.Console.WriteLine("Нажмите Enter, чтобы добавить блок данных.");
    System.Console.ReadLine();

    int[] block = new int[elementCount];

    for (int i = 0; i < block.Length; i++)
    {
        block[i] = 1;
    }
    blocks.Add(block);

    long currentMemory = Environment.WorkingSet;
    long dataBytes = 1L * blocks.Count * elementCount * bytesPerElement;
    System.Console.WriteLine($"Шаг {step}. Сохранено массивов: {blocks.Count}");
    System.Console.WriteLine($"Объём элементов: {dataBytes / bytesPerMiB:F2} MiB");
    System.Console.WriteLine($"Рабочий набор: {currentMemory / bytesPerMiB:F2} MiB");
    System.Console.WriteLine($"Изменение от начала: {(currentMemory - startMemory) / bytesPerMiB:F2} MiB");
}

System.Console.WriteLine("Данные сохранены в памяти. Нажмите Enter для завершения.");
System.Console.ReadLine();

long check = 0;
foreach (int[] block in blocks)
{
    check += block[0];
}
System.Console.WriteLine($"Контрольная сумма первых элементов: {check}");
