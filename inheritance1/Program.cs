using System;

public class PokokDanKomisiPegawai
{
	public string NamaDepan { get; }
	public string NamaBelakang { get; }
	public string NomorKTP { get; }
	private decimal penjualanKotor; // penjualan kotor mingguan
	private decimal tarifKomisi; // prosentase komisi/100
	private decimal gajiPokok; // gaji pokok per minggu

	// konstruktor enam parameter
	public PokokDanKomisiPegawai(string namaDepan, string namaBelakang,
	string nomotKTP, decimal penjualanKotor,
	decimal tarifKomisi, decimal gajiPokok)
	{
		// panggilan implisit ke konstruktor objek terjadi disini
		NamaDepan = namaDepan;
		NamaBelakang = namaBelakang;
		NomorKTP = nomotKTP;
		PenjualanKotor = penjualanKotor; // memvalidasi penjualan kotor
		TarifKomisi = tarifKomisi; // memvalidasi tarif komisi
		GajiPokok = gajiPokok; // memvalidasi gaji pokok

	}

    // get dan set penjualan kotor
    public decimal PenjualanKotor
	{
		get
		{
			return penjualanKotor;
		}
		set
		{
			if (value < 0) // validation
			{
				throw new ArgumentOutOfRangeException(nameof(value),
				value, $"{nameof(PenjualanKotor)} must be >= 0");
			}

			penjualanKotor = value;
		}
	}

	// get dan set tarif komisi
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

	// get dan set gaji pokok dari PokokDanKomisiPegawai
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
	public decimal Pendapatan() =>
	gajiPokok + (tarifKomisi * penjualanKotor);

	// mengembalikan representasi string dari objek PokokDanKomisiPegawai 
	public override string ToString() =>
	$"nama pegawai komisi dan gaji pokok: {NamaDepan} {NamaBelakang}\n" +
	$"nomor kartu tanda penduduk: {NomorKTP}\n" +
	$"penjualan kotor: {penjualanKotor:C}\n" +
	$"tarif komisi: {tarifKomisi:F2}\n" +
	$"gaji pokok: {gajiPokok:C}";
}

class PokokDanKomisiPegawaiTest
{
	static void Main()
	{
		// memberikan contoh nilai dari objek PokokDanKomisiPegawai 
		var employee = new PokokDanKomisiPegawai("Bob", "Lewis",
	        "333-33-3333", 5000.00M, .04M, 300.00M);
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



