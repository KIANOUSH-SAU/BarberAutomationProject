import { Link } from "react-router-dom";
import { homeBackground } from "../assets/assetsHandler";
import gsap from "gsap";
import { useGSAP } from "@gsap/react";
const HomePage = () => {
	useGSAP(() => {
		gsap.to(".bg-animation", {
			scale: 1.1,
			duration: 20,
			ease: "power1.inOut",
			repeat: -1,
			yoyo: true,
		});
	}, []);
	return (
		<div className="min-h-screen max-h-screen flex flex-col items-center justify-center relative overflow-hidden">
			{/* Animated background layer */}
			<div
				className="absolute inset-0 bg-cover bg-center bg-no-repeat bg-animation"
				style={{
					backgroundImage: `url(${homeBackground})`,
				}}
			></div>

			{/* Dark overlay */}
			<div className="absolute inset-0 bg-black/40"></div>

			<div className="text-center relative z-10 glass-bg rounded-3xl p-20 max-w-3xl mx-4">
				<h1 className="text-6xl font-bold text-white mb-4 drop-shadow-lg">
					Hoş Geldiniz
				</h1>
				<p className="text-xl text-white/90 mb-8">
					Müşteriler kolayca randevu alabilir ve işletmeler randevu
					takibi yapabilir.
				</p>
				<div className="space-x-4">
					<Link to="/services" className="btn-type-2 justify-center">
						Hizmetlerimiz
					</Link>
					<Link
						to="/appointments"
						className="btn-type-3 justify-center"
					>
						Yönetici Girişi
					</Link>
				</div>
			</div>
		</div>
	);
};

export default HomePage;
