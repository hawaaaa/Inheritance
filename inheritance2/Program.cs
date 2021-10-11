using System;

public class PegawaiKomisi 
{
	public string NamaDepan { get; }
	public string NamaBelakang { get; }
	public string NomorKTP { get; }
	private decimal penjualanKotor; // penjualan kotor mingguan
	private decimal tarifKomisi; // prosentase komisi/100


	// konstruktor lima parameter
	public PegawaiKomisi(string namaDepan, string namaBelakang,
	  string nomorKTP, decimal penjualanKotor,
	  decimal tarifKomisi)
	{
		// panggilan implisit ke konstruktor objek terjadi disini
		NamaDepan = namaDepan;
		NamaBelakang = namaBelakang;
		NomorKTP = nomorKTP;
		PenjualanKotor = penjualanKotor; // memvalidasi penjualan kotor
		TarifKomisi = tarifKomisi; // memvalidasi tarif komisi
	}

	// get dan set penjualan kotor pegawai
	public decimal PenjualanKotor
	{
		get
		{
			return penjualanKotor;
		}
		set
		{
			if (value < 0) // validasi
			{
				throw new ArgumentOutOfRangeException(nameof(value),
				value, $"{nameof(PenjualanKotor)} must be >= 0");
			}
			penjualanKotor = value;
		}
	}

	public decimal TarifKomisi
	{
		get
		{
			return tarifKomisi;
		}
		set
		{
			if (value <= 0 || value >= 1) // validasi
			{
				throw new ArgumentOutOfRangeException(nameof(value),
				value, $"{nameof(TarifKomisi)} must be > 0 and < 1");
			}

			tarifKomisi = value;
		}
	}

	// menghitung pendapatan komisi pegawai
	public virtual decimal Pendapatan() => TarifKomisi * PenjualanKotor;
	// mengembalikan string representasi dari objek PegawaiKomisi
	public override string ToString() =>
	  $"pegawai komisi dan gaji pokok: {NamaDepan} {NamaBelakang}\n" +
	  $"nomor kartu tanda penduduk: {NomorKTP}\n" +
	  $"pendapatan kotor: {PenjualanKotor:C}\n" +
	  $"tarif komisi: {TarifKomisi:F2}";
}
public class PokokDanKomisiPegawai : PegawaiKomisi
{
	private decimal gajiPokok; // gaji pokok per minggu

	// enam parameter konstruktor kelas turunan
	// dengan memanggil ke konstruktor PegawaiKomisi kelas dasar 
	public PokokDanKomisiPegawai(string namaDepan, string namaBelakang,
	   string nomorKTP, decimal penjualanKotor,
	   decimal tarifKomisi, decimal gajiPokok)
	   : base(namaDepan,namaBelakang,nomorKTP,penjualanKotor,tarifKomisi)

	{
		GajiPokok = gajiPokok; // memvalidasi gaji pokok
	}

	public decimal GajiPokok
	{
		get
		{
			return gajiPokok;
		}
		set
		{
			if (value < 0) // validasi
			{
				throw new ArgumentOutOfRangeException(nameof(value),
				value, $"{nameof(GajiPokok)} must be >= 0");
			}

			gajiPokok = value;
		}
	}

	// menghitung pendapatan 
	public override decimal Pendapatan() => GajiPokok + base.Pendapatan();

	// mengembalikan representasi string dari objek PokokDanKomisiPegawai
	public override string ToString() =>
	   $"nama {base.ToString()}\ngaji pokok: {GajiPokok:C}";
}
class PokokDanKomisiPegawaiTest
{
	static void Main()
	{
		// memberikan contoh nilai dari objek PokokDanKomisiPegawai
		var employee = new PokokDanKomisiPegawai("Bob", "Lewis", "333-33-3333", 5000.00M, .04M, 300.00M);
		// menampilkan data PokokDanKomisiPegawai 
		Console.WriteLine(
		"Informasi pegawai yang diperoleh dengan properti dan metode: \n");
		Console.WriteLine($"Nama Depan adalah {employee.NamaDepan}");
		Console.WriteLine($"Nama Belakang adalah {employee.NamaBelakang}");
		Console.WriteLine(
		$"Nomor Kartu Tanda Penduduk adalah {employee.NomorKTP}");
		Console.WriteLine($"Penjualan Kotor sebesar {employee.PenjualanKotor:C}");
		Console.WriteLine(
		$"Tarif Komisi sebesar {employee.TarifKomisi:F2}");
		Console.WriteLine($"Gaji Pokok sebesar {employee.GajiPokok:C}");
		Console.WriteLine($"Pendapatan sebesar {employee.Pendapatan():C}");
		

		employee.GajiPokok = 1000.00M; // set gaji pokok

		Console.WriteLine(
		"\nUpdate informasi pegawai yang diperoleh dengan ToString:\n");
		Console.WriteLine(employee);
		Console.WriteLine($"pendapatan: {employee.Pendapatan():C}");
	}
}







