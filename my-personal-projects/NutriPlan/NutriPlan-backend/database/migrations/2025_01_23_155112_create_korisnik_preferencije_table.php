<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('korisnik_preferencije', function (Blueprint $table) {
            $table->unsignedBigInteger('korisnik_id');
            $table->unsignedBigInteger('preferencija_id');
            $table->foreign('korisnik_id')->references('id')->on('korisnici');
            $table->foreign('preferencija_id')->references('id')->on('preferencije');
            $table->primary(['korisnik_id', 'preferencija_id']);
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('korisnik_preferencije');
    }
};
