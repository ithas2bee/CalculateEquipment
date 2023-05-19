using System;
using System.Collections.Generic;

namespace EquipmentROI
{
    class Equipment
    {
        public string Brand { get; set; }
        public decimal Gain { get; set; }
        public decimal Cost { get; set; }
        public decimal ROI { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<Equipment> equipmentList = new LinkedList<Equipment>();

            // Prompt the user to enter the equipment details
            Console.WriteLine("Enter the details for three different pieces of equipment:");
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Equipment {i}:");
                Console.Write("Brand: ");
                string brand = Console.ReadLine();
                Console.Write("Gain: ");
                decimal gain = decimal.Parse(Console.ReadLine());
                Console.Write("Cost: ");
                decimal cost = decimal.Parse(Console.ReadLine());

                equipmentList.AddLast(new Equipment
                {
                    Brand = brand,
                    Gain = gain,
                    Cost = cost,
                    ROI = (gain - cost) / cost
                });

                Console.WriteLine();
            }

            // Sort the equipment list by ROI in descending order
            equipmentList = SortByROI(equipmentList);

            // Display the sorted equipment list with ROI
            Console.WriteLine("Sorted Equipment List (Best to Least ROI):");
            foreach (var equipment in equipmentList)
            {
                Console.WriteLine($"Brand: {equipment.Brand}");
                Console.WriteLine($"Gain: {equipment.Gain:C}");
                Console.WriteLine($"Cost: {equipment.Cost:C}");
                Console.WriteLine($"ROI: {equipment.ROI:P}");
                Console.WriteLine();
            }

            Console.WriteLine("Program completed processing.");
        }

        static LinkedList<Equipment> SortByROI(LinkedList<Equipment> equipmentList)
        {
            var sortedList = new LinkedList<Equipment>();

            foreach (var equipment in equipmentList)
            {
                if (sortedList.First == null || equipment.ROI >= sortedList.First.Value.ROI)
                {
                    sortedList.AddFirst(equipment);
                }
                else
                {
                    var currentNode = sortedList.First;

                    while (currentNode.Next != null && equipment.ROI < currentNode.Next.Value.ROI)
                    {
                        currentNode = currentNode.Next;
                    }

                    sortedList.AddAfter(currentNode, equipment);
                }
            }

            return sortedList;
        }
    }
}
