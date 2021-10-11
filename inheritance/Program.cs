using System;

public class PegawaiKomisi : object
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
	// get dan set komisi pegawai
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
	public decimal Pendapatan() => tarifKomisi * penjualanKotor;
	// mengembalikan representasi string dari objek PegawaiKomisi
	public override string ToString() =>
	$"nama pegawai komisi: {NamaDepan} {NamaBelakang}\n" +
	$"nomor kartu tanda penduduk: {NomorKTP}\n" +
	$"pendapatan kotor: {penjualanKotor:C}\n" +
	$"tarif komisi: {tarifKomisi:F2}";
}
class PegawaiKomisiTest
{
	static void Main()
	{
		// Memberikan contoh nilai dari objek PegawaiKomisi
		var employee = new PegawaiKomisi("Sue", "Jones",
            "222-22-2222", 10000.00M, .06M);


		// Menampilkan data PegawaiKomisi 
		Console.WriteLine(
		"Informasi pegawai yang diperoleh dengan properti dan metode: \n");
		Console.WriteLine($"Nama Depan adalah {employee.NamaDepan}");
		Console.WriteLine($"Nama Belakang adalah {employee.NamaBelakang}");
		Console.WriteLine(
		$"Nomor Kartu Tanda Penduduk adalah {employee.NomorKTP}");
		Console.WriteLine($"Pendapatan Kotor sebesar {employee.PenjualanKotor:C}");
		Console.WriteLine(
		$"Tarif Komisi sebesar {employee.TarifKomisi:F2}");
		Console.WriteLine($"Pendapatan Komisi sebesar {employee.Pendapatan():C}");

		employee.PenjualanKotor = 5000.00M; // set pendapatan kotor
		employee.TarifKomisi = .1M; // set tarif komisi


		Console.WriteLine(
		"\nUpdate informasi pegawai yang diperoleh dengan ToString:\n");
		Console.WriteLine(employee);
		Console.WriteLine($"pendapatan komisi: {employee.Pendapatan():C}");
	}
}









