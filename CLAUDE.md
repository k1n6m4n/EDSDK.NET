@../qbooth-hub/CLAUDE.md

# EDSDK.NET — the Canon camera wrapper

The user's fork of the "Canon EDSDK Tutorial in C#" wrapper, upgraded to Canon
SDK 3.6. Its build ships inside the WPF app as `libs\Canon\EDSDK.NET.dll`.

- **Read [edsdk-net-dll-source](../QBoothWPF/md_files/edsdk-net-dll-source.md) before
  any change.** Work on `master` (the fix branch was merged into it on 27-10-2026).
  It's the **Debug** build that ships.
- After a rebuild, copy the DLL into `../QBoothWPF/libs/Canon/` and record the new
  hash + commit in that memory file.
- Open work (crashes on the download thread): [CANON_UI_THREAD_FIX](../QBoothWPF/md_files/CANON_UI_THREAD_FIX.md).
