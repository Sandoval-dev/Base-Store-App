using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    /// <summary>
    /// struct ile değer tipli bir yapı oldu. -- record veya class anahtar kelimesinin farkı yok
    /// Data Transfer Object - Değişmez değerlerdir. readonly veya immutable olarak tanımlanmalıdır.
    /// init yazarsanız readonly bir ifade alırsınız
    /// </summary>
    public record BookDtoForUpdate(int Id, string Title, decimal Price);
 
}
