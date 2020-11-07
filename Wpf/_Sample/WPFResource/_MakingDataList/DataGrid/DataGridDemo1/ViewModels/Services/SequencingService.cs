using DataGridDemo1.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridDemo1.ViewModels.Services
{
    public class SequencingService
    {
        /// <summary>
        /// Resets the sequential order of a collection.
        /// </summary>
        /// <param name="targetCollection">The collection to be re-indexed.</param>
        /// //값을 여기서 순서 번호주나보네
        public static ObservableCollection<T> SetCollectionSequence<T>(ObservableCollection<T> targetCollection) where T : ISequencedObject
        {
            // Initialize
            var sequenceNumber = 1;

            // Resequence
            foreach (ISequencedObject sequencedObject in targetCollection)
            {
                sequencedObject.SequenceNumber = sequenceNumber;
                sequenceNumber++;
            }

            // Set return value
            return targetCollection;
        }
    }
}
